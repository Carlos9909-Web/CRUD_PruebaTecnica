$(document).ready(function () {

    var totalGanancia = 0;

    $(".venta").each(function () {
        totalGanancia += parseInt($(this).html()) || 0;
    });
    $("#ventaTotal").text(totalGanancia);

    totalGanancia = 0;
    $(".ganancia").each(function () {
        totalGanancia += parseInt($(this).html()) || 0;
    });
    $("#gananciaTotal").text(totalGanancia);

    $("#CatidadVendidos").text($("#tablaGanancia").find('tbody tr').length);
});