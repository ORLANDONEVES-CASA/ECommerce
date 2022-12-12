const MODELO_BASE = {
    medidaId: 0,
    descripcion: "",
    escala: "",
    isActive: 0,
    registrationDate: "",
}

let tablaData;

$(document).ready(function () {

    $('#tbdata').DataTable({
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
        },
        "aLengthMenu": [
            [25, 50, 100, 200, -1],
            [25, 50, 100, 200, "Todos"]
        ]
    });
    
    //tablaData = $('#tbdata').DataTable({
    //    responsive: true,
    //    processing: true,
    //    "ajax": {
    //        "url": '/Medidum/Lista',
    //        "type": "GET",
    //        "datatype": "json"
    //    },
    //    "columns": [
    //        { "data": "medidaId", "visible": false, "searchable": false },
    //        { "data": "descripcion" },
    //        { "data": "escala" },
    //        {
    //            "data": "isActive", render: function (data) {
    //                if (data == 1)
    //                    return '<span class="badge badge-info">Activo</span>';
    //                else
    //                    return '<span class="badge badge-danger">No Activo</span>';
    //            }
    //        },
    //        {
    //            "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
    //                '<button class="btn btn-danger btn-eliminar btn-sm"><i class="fas fa-trash-alt"></i></button>',
    //            "orderable": false,
    //            "searchable": false,
    //            "width": "80px"
    //        }
    //    ],
    //    order: [[0, "desc"]],
    //    dom: "Bfrtip",
    //    buttons: [
    //        {
    //            text: 'Exportar Excel',
    //            extend: 'excelHtml5',
    //            title: '',
    //            filename: 'Reporte Medidas',
    //            exportOptions: {
    //                columns: [0,1,2, 3]
    //            }
    //        }, 'pageLength'
    //    ],
    //    language: {
    //        url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
    //    },
    //});

})


function mostrarModal(modelo = MODELO_BASE) {
    //$("#txtId").val(modelo.idProducto)

    //$("#txtCodigoBarra").val(modelo.codigoBarra)
    //$("#txtMarca").val(modelo.marca)
    //$("#txtDescripcion").val(modelo.descripcion)
    //$("#cboCategoria").val(modelo.idCategoria == 0 ? $("#cboCategoria option:first").val() : modelo.idCategoria)
    //$("#txtStock").val(modelo.stock)
    //$("#txtPrecio").val(modelo.precio)
    //$("#cboEstado").val(modelo.esActivo)
    //$("#txtImagen").val("")
    //$("#imgProducto").attr("src", modelo.urlImagen)


    $("#modalData").modal("show")
}

$("#btnNuevo").click(function () {
    mostrarModal()
})
let filaSeleccionada;
$("#tbdata tbody").on("click", ".btn-editar", function () {

    if ($(this).closest("tr").hasClass("child")) {
        filaSeleccionada = $(this).closest("tr").prev();
    } else {
        filaSeleccionada = $(this).closest("tr");
    }

    const data = tablaData.row(filaSeleccionada).data();

    mostrarModal(data);

})
