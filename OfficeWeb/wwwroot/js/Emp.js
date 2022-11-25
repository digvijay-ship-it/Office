var dataTable;
$(document).ready(function (){
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Emp/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "departmentRole.name", "width": "15%" },
            { "data": "userRole.userRoleType", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div>
                        <a href = "/Emp/Upsert?id=${data}"
                           class="btn btn-primary"  >Edit</a>
                        <a onClick = Delete('Emp/Delete/${data}')
                           class="btn btn-danger" >Delete</a>
                    </div>
                        `
                },
                "width": "15%"
            },
        ]
    });
}

function Delete(url) {
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
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.success(data.message);
                    }
                }
            })
        }
    })
}