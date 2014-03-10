var Url = null;

(function () {

  //
  // Mvc route parser implementation
  //

  var mvcRouteParser = function () {
  };

  mvcRouteParser.prototype = {
    routes: null,

    _registerRoutes: function (routeCollection) {
      this.routes = routeCollection;
    },

    _routeUrl: function (routeName, parameters) {
      if (this.routes == null) {
        throw new Error('Routes were not registered yet');
      }
      if (!this.routes.length) {
        throw new Error('No route was registered');
      }
      var route = this._findRoute(routeName);
      if (route == null) {
        throw new Error('Unable to find route ' + routeName);
      }
      return this._parse(route.Path, parameters);
    },

    _parse: function (routePath, parameters) {
      var url = routePath;
      for (var i = 0; i < parameters.length; i++) {
        var parameter = parameters[i];
        var parameterName = Object.keys(parameter)[0];
        var parameterValue = parameter[parameterName];
        var searchPattern1 = '{' + parameterName + '}';
        if (url.indexOf(searchPattern1) >= 0) {
          url = url.replaceAll(searchPattern1, parameterValue);
        } else {
          var searchPattern2 = '{*' + parameterName + '}';
          if (url.indexOf(searchPattern2) >= 0) {
            url = url.replaceAll(searchPattern2, parameterValue);
          } else {
            url = this._appendQueryParameter(url, parameterName, parameterValue);
          }
        }
      }
      url = this._removeUnusedParameters(url);
      return url;
    },

    _findRoute: function (routeName) {
      for (var i = 0; i < this.routes.length; i++) {
        var route = this.routes[i];
        if (routeName === route.Name) {
          return route;
        }
      }
      return null;
    },

    _appendQueryParameter: function (url, parameterName, parameterValue) {
      var hasAnyParameter = url.indexOf('?') >= 0;
      var separator = (hasAnyParameter) ? '&' : '?';
      return url + separator + parameterName + '=' + parameterValue;
    },

    _removeUnusedParameters: function (url) {
      var regex = new RegExp('{.*}');
      url = url.replace(regex, '');
      url = this._removeTrailingSlash(url);
      return url;
    },

    _removeTrailingSlash: function (url) {
      if (url.endsWith('/')) {
        return url.substring(0, url.length - 1);
      }
      url = url.replaceAll('/?', '?');
      return url;
    }
  };

  //
  // Url implementation
  //

  Url = function () {
  };

  Url.registerRoutes = function (routes) {
    Url._getParserImplementation()._registerRoutes(routes);
  };

  Url.routeUrl = function (routeName, parameters) {
    return Url._getParserImplementation()._routeUrl(routeName, parameters);
  };

  Url._getParserImplementation = function () {
    if (Url._parser == null) {
      Url._parser = new mvcRouteParser();
    }
    return Url._parser;
  };

  Url._parser = null;

  //
  // String extensions
  //

  String.prototype.replaceAll = function (find, replace) {
    var str = this;
    return str.replace(new RegExp(find.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&'), 'g'), replace);
  };

  String.prototype.endsWith = function (suffix) {
    return this.indexOf(suffix, this.length - suffix.length) !== -1;
  };

})();
