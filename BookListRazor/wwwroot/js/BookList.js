var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "30%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/BookList/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:60px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a  class='btn btn-danger text-white' style='cursor:pointer; width:70px;' onclick=Delete('/api/book?id='+${data})>
                                Delete
                            </a>
                        </div>
                    `;
                }, "width":"30%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        },
        "width": "100%"
    })
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        showCancelButton: true,
        dangerMode: true,
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((willDelete) => {
        if (willDelete.value) {
            $.ajax({
                type: "Delete",
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
            });
        }
    });
}