angular.module('myFormApp', []).
    controller('CalculatorController', function ($scope, $http, $location, $window) {
        $scope.calc = {};
        $scope.calc.Operation = "add";
        $scope.message = '';
        $scope.result = "color-default";
        $scope.isViewLoading = false;

        //get called when user submits the form
        $scope.submitForm = function () {
            $scope.isViewLoading = true;
            console.log('Form is submitted with:', $scope.calc);

            //$http service that send or receive data from the remote server
            $http({
                method: 'POST',
                url: '/Home/Calculate',
                data: $scope.calc
            }).success(function (data, status, headers, config) {
                $scope.errors = [];
                if (data.success === true) {
                    $scope.calc = data.result;
                    $scope.message = `Result is ${$scope.calc.Result}  !`;
                    $scope.result = "color-green";
                    //$location.path(data.redirectUrl);
                    //$window.location.reload();
                }
                else {
                    $scope.errors = data.errors;
                }
            }).error(function (data, status, headers, config) {
                $scope.errors = [];
                $scope.message = 'Unexpected Error while calculating data!!';
            });
            $scope.isViewLoading = false;
        }
    })
    .config(function ($locationProvider) {

        //default = 'false'
        $locationProvider.html5Mode(true);
    });
