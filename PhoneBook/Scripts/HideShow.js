$(".deleteButton").hide();
$("#showdelete").click(function myFunction() {
    $(".editButton").hide(1000);
    $(".deleteButton").show(1000);
});

$(".editButton").hide();
$("#showedit").click(function myFunction() {
    $(".deleteButton").hide(1000);
    $(".editButton").show(1000);
});

