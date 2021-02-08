var dataTable;


$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/ToDo",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
        { "data": "name", "width": "10%" },
            { "data": "task", "width": "10%" },
            { "data": "subTask", "width": "10%" },
            { "data": "status", "width": "10%" },
            { "data": "remarks", "width": "10%" },
            { "data": "createdDate", "width": "10%" },
            { "data": "updatedDate", "width": "10%" },
        {
            "data": "id",
            "render": function (data) {
                return `<div class="text-center">
                <a href="/ToDoList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                Edit
                </a>
                  &nbsp;
                 <a class='btn btn-danger text-white' style='cursor:pointer; width:100px;'
                onclick=Delete('/api/ToDo?id='+${data})>
                 Delete
                </a>
                </div>`;
              
            }, "width": "40%"
        }
        ],
        "language": {
            "emptyTable": "no data found"
    },
        "width" : "100%"
    })
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}