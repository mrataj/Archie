test("Check if url engine is loaded", function () {
  notEqual(Url, undefined);
});

test("Parse basic route with optional parameters", function () {
  var route = Url.routeUrl("Default", [{ controller: "Home" }]);
  equal(route, "Home");
});

test("Parse route with two url parameters", function () {
  var route = Url.routeUrl("Default", [{ controller: "Home" }, { action: "Index" }]);
  equal(route, "Home/Index");
});

test("Parse route with single query parameter", function () {
  var route = Url.routeUrl("Default", [{ controller: "Home" }, { action: "Index" }, { sort: "5"}]);
  equal(route, "Home/Index?sort=5");
});

test("Parse route with multiple query parameters", function () {
  var route = Url.routeUrl("Default", [{ controller: "Home" }, { action: "Index" }, { sort: "5" }, { view: "2" }]);
  equal(route, "Home/Index?sort=5&view=2");
});
