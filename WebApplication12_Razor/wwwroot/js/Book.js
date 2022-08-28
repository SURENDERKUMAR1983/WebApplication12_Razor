

var datatable;
$(document).ready(function () {
    loaddataTable();
});

function loaddataTable() {
    datatable = $('#tbldata').DataTable({
        "ajax": {
            "url": "api/book",
            "type": "GET",            
            "datatype":"json"
        },
        "columns":[
            { "data": "title", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                 
                "render": function (data) {
                    return `
                  <div class="text-center">
                     <a href="/booklist/Upserrt?id=${data}"class="btn btn-info">Upsert </a >                     
                     <a class="btn btn-danger" onclick=Delete("api/book?id=${data}")>Delete </a >
                     </div>
                    `;
                }




            }
        ]


    })
}
function Delete(url) {
    //alert(url);
    swal ({
        title: "want to delete data?",
        text: "delete information!!!",
        buttons: true,
        dangerModel:true,
        icon:"warning"
    }).then((willdelete) => {
        if (willdelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if(data.success)
                    {
                       /* alert('this is if');*/
                        toastr.success(data.message);
                          datatable.ajax.reload();
                        
                    }
                    else
                    {
                       /* alert('this is else');*/
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}