var dataTable;
$(document).ready(function (){
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/WorkReport/GetAll"
        },
        "columns": [
            { "data": "emp.name", "width": "15%" },
            { "data": "reportType", "width": "15%" },
            { "data": "reportDesc", "width": "15%" }
            /*{
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
            },*/
        ]
    });
}