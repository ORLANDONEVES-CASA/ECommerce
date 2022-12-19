const _modeloiva = {
    ivaid: 0,
    descripcion: "",
    tarifa: 0,
    isActive: 0,
    registrationDate: ""
}

let tablaData;

function MostrarIvas() {

    fetch("/Ivas/listaIvas")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response)
        })
        .then(responseJson => {
            if (responseJson.length > 0) {

                $("#tablaIvas tbody").html("");


                responseJson.forEach((iva) => {
                    $("#tablaIvas tbody").append(
                        $("<tr>").append(
                            $("<td>").text(iva.descripcion),
                            $("<td>").text(iva.tarifa),
                            $("<td>").text(iva.isActive),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-primary btn-sm boton-editar-empleado").text("Editar").data("dataIva", iva),
                                $("<button>").addClass("btn btn-danger btn-sm ms-2 boton-eliminar-empleado").text("Eliminar").data("dataIva", iva),
                            )
                        )
                    )
                })

            }
        })
}

//function MostrarIvasdocument() {
//    tablaData = $('#tbdata').DataTable({
//        responsive: true,
//        "ajax": {
//            "url": '/Ivas/Lista',
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "ivaId", "visible": false, "searchable": false },
//            { "data": "descripcion" },
//            { "data": "tarifa" },
//            {
//                "data": "IsActive", render: function (data) {
//                    if (data == 1)
//                        return '<span class="badge badge-info">Activo</span>';
//                    else
//                        return '<span class="badge badge-danger">No Activo</span>';
//                }
//            },
//            {
//                "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"><i class="fas fa-pencil-alt"></i></button>' +
//                    '<button class="btn btn-danger btn-eliminar btn-sm"><i class="fas fa-trash-alt"></i></button>',
//                "orderable": false,
//                "searchable": false,
//                "width": "80px"
//            }
//        ],
//        order: [[0, "desc"]],
//        dom: "Bfrtip",
//        buttons: [
//            {
//                text: 'Exportar Excel',
//                extend: 'excelHtml5',
//                title: '',
//                filename: 'Reporte Iva',
//                exportOptions: {
//                    columns: [2, 3]
//                }
//            }, 'pageLength'
//        ],
//        language: {
//            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
//        },
//    });
//}

document.addEventListener("DOMContentLoaded", function () {

    MostrarIvas();
    //MostrarIvasdocument();
    //fetch("/Home/listaDepartamentos")
    //    .then(response => {
    //        return response.ok ? response.json() : Promise.reject(response)
    //    })
    //    .then(responseJson => {

    //        if (responseJson.length > 0) {
    //            responseJson.forEach((item) => {

    //                $("#cboDepartamento").append(
    //                    $("<option>").val(item.idDepartamento).text(item.nombre)
    //                )

    //            })
    //        }

    //    })

    //$("#txtFechaContrato").datepicker({
    //    format: "dd/mm/yyyy",
    //    autoclose: true,
    //    todayHighlight: true
    //})


}, false)




function MostrarModal() {

    $("#txtDescripcion").val(_modeloiva.descripcion);
    $("#txtTarifa").val(_modeloiva.tarifa);


    $("#modalIvas").modal("show");

}

$(document).on("click", ".boton-nuevo-empleado", function () {

    _modeloiva.ivaid = 0;
    _modeloiva.descripcion = "";
    _modeloiva.tarifa = 0;
    _modeloiva.isActive = 0;
    _modeloiva.registrationDate = "";

    MostrarModal();

})


$(document).on("click", ".boton-editar-empleado", function () {

    const _iva = $(this).data("dataIva");


    _modeloiva.ivaid = _iva.ivaId;
    _modeloiva.descripcion = _iva.descripcion;
    _modeloiva.tarifa = _iva.tarifa;
    _modeloiva.isActive = _iva.isActive;
    _modeloiva.registrationDate = _iva.registrationDate;

    MostrarModal();

})


$(document).on("click", ".boton-eliminar-empleado", function () {

    const _iva = $(this).data("dataIva");

    Swal.fire({
        title: "Esta seguro?",
        text: `Eliminar IVA "${_iva.descripcion}" Error  :"${_iva.ivaId}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, volver"
    }).then((result) => {

        if (result.isConfirmed) {

            fetch(`/Ivas/eliminarIvas?ivaId=${_iva.ivaId}`, {
                method: "DELETE"
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        Swal.fire("Listo!", "Iva fue elminado", "success");
                        MostrarIvas();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
                })

        }



    })

})


$(document).on("click", ".boton-guardar-cambios-empleado", function () {

    if ($("#txtDescripcion").val().trim() == "") {
        toastr.warning("", "Debe completa el campo : descripcion")
        $("#txtDescripcion").focus()
        return;
    }
    valor = $("#txtTarifa").val();
    if (isNaN(valor)) {
        toastr.warning("", "Debe completa el campo : Tarifa")
        $("#txtTarifa").focus()
        return;
    }

    if (valor >= 1) {
        toastr.warning("", "El Valor de la Tarifa debe ser en porcentaje y no mayor a 1 : Tarifa")
        $("#txtTarifa").focus()
        return;
    }
    var rd = new Date();
    const modelo = {
        ivaid: _modeloiva.ivaid,
        descripcion: $("#txtDescripcion").val(),
        Tarifa: $("#txtTarifa").val(),
        isActive: 1,
        registrationDate: rd
    }


    if (_modeloiva.ivaid == 0) {

        fetch("/Ivas/guardarIvas", {
            method: "POST",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {

                if (responseJson.valor) {
                    $("#modalIvas").modal("hide");
                    Swal.fire("Listo!", "Iva fue creado", "success");
                    MostrarIvas();
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo crear", "error");
            })

    } else {

        fetch("/Ivas/editarIvas", {
            method: "PUT",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {

                if (responseJson.valor) {
                    $("#modalIvas").modal("hide");
                    Swal.fire("Listo!", "Iva fue actualizado", "success");
                    MostrarIvas();
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo actualizar", "error");
            })

    }


})

