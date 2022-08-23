$(function () {
    initForm();
});

$("#cmdCalc").click(function () {
    var meal = parseFloat($("#txtSubTotal").val());
    var diners = parseFloat($("#txtNumDiners").val());
    var percent = parseFloat($("#txtTipPercent").val());

    if (diners < 1)
        diners = 1;

    // Calculate the values
    var tip = meal * (percent / 100);
    var totalMeal = meal + tip;
    var perDiner = totalMeal / diners;

    // Round values off to two decimal places
    tip = tip.toFixed(2);
    totalMeal = totalMeal.toFixed(2);
    perDiner = perDiner.toFixed(2);

    // Put the numbers into the form.
    $("#txtTipAmount").val(tip);
    $("#txtTotal").val(totalMeal);
    $("#txtPerDiner").val(perDiner);
});

$("#cmdClear").click(function () {
    initForm();
});

function initForm() {
    $("#txtSubTotal").val(0);
    $("#txtNumDiners").val(1);
    $("#txtTipPercent").val(10);
    $("#txtTipAmount").val(0);
    $("#txtTotal").val(0);
    $("#txtPerDiner").val(0);
}