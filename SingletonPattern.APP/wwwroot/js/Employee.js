var dtable;
$(document).ready(function () {

    dtable = $('#myTable').DataTable({

        "ajax": { "url": "/Employees/GetAllEmployees" },
        "columns": [
            { "data": "emailAddress" },
            { "data": 'country.countryName' },
            { "data": "state.stateName" },
            { "data": "city.cityName" },
            { "data": "panNumber" },
            { "data": "passportNumber" },
            {
                "data": "gender",
                "render": function (data, type, row) {
                    if (type === 'display') {
                        return data == 0 ? 'Male' : 'Female';
                    }
                    return data;
                }
             },
            { "data": "isActive" },
            {
                data: 'profileImage',
                render: function (data, type, row) {                    
                    return `<img src="${data}" alt="Profile Image" style="width:50px; height:50px; border-radius:50%;" />`;
                }
            },
            {
                "data": "row_Id",
                "render": function (data) {
                    return `
                            <a href="/Employees/Register?id=${data}"><i class="bi bi-pencil-square"></i></a>
                <a onclick=RemoveProduct("/Employees/Delete/${data}")><i class="bi bi-trash"></i></a>
       
`   }
            }
        ]

    });
});
function RemoveProduct(url) {

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dtable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }



            });

        }
    })

}