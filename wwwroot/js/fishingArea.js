var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/FishingAreas/GetAllFishingArea",
            "type": "GET",
            "datatype": "json"

        },
        "columns": [
            { "data": "Waterbody", "width": "50%" },
            { "data": "Town", "width": "50%" },
            { "data": "County", "width": "50%" },
            {
                "data": "Id",
                "render": function (data) {
                    return `<div class= "text-center">
                                <a href ="/fishingAreas/Upsert/${data}" class= 'btn btn-success text-white'
                                    style='cursor:pointer;'> <i class = 'far fa-edit' ></i></a>
                                    &nbsp;
                                <a onclick =Delete("/fishingAreas/Delete/${data}") class= 'btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class = 'far fa-edit' ></i></a>
                           </div>
                          `;
                }, width: "30%"
            }
        ]
    });
}
