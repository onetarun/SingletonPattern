$(document).ready(function () {
         
            // Load states when country changes
            $('#CountryId').change(function () {
                var countryId = $("#CountryId").val();
                if (countryId) {
                    $.ajax({
                        url: '/Employees/GetStatesByCountry',
                        type: 'GET',
                        data: { countryId: countryId },
                        success: function (data) {
                            $('#StateId').html('<option value="">Select State</option>');
                            $.each(data, function (index, state) {
                                $('#StateId').append('<option value="' + state.row_Id + '">' + state.stateName + '</option>');
                            });
                            $('#StateId').prop('disabled', false); // Enable state dropdown
                            $('#CityId').prop('disabled', true); // Disable city dropdown
                            $('#CityId').html('<option value="">Select City</option>');
                        }
                    });
                } else {
                    $('#StateId').prop('disabled', true);
                    $('#CityId').prop('disabled', true);
                }
            });

            // Load cities when state changes
            $('#StateId').change(function () {
                var stateId = $("#StateId").val();
                if (stateId) {
                    $.ajax({
                        url: '/Employees/GetCitiesByState',
                        data: { stateId: stateId },
                        type: 'GET',
                        success: function (data) {
                            $('#CityId').html('<option value="">Select City</option>');
                            $.each(data, function (index, city) {
                                $('#CityId').append('<option value="' + city.row_Id + '">' + city.cityName + '</option>');
                            });
                            $('#CityId').prop('disabled', false); // Enable city dropdown
                        }
                    });
                } else {
                    $('#CityId').prop('disabled', true);
                }
            });
        });