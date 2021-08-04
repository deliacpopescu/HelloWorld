//Js code
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            url: "/Home/AddTeamMembers",
            method: "POST",
            data: {
                name: newcomerName
            },
            success: function (result)  {
                $("#list").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            }
    })
});
