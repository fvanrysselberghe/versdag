angular.module('VersdagApp', [])
    .controller('SuggestionCtrl', function ($scope, $http) {
        $scope.suggested = false;
        $scope.suggestion = "loading suggestion...";

        $scope.nextSuggestion= function () {
            $scope.suggested = false;
            $scope.suggestion = "loading suggestion...";

            $http.get("/api/suggestion").success(function (data, status, headers, config) {
                $scope.suggestion = data.Name;
                $scope.suggested = true;
            }).error(function (data, status, headers, config) {
                $scope.title = "Oops... something went wrong";
            });
        };

    });