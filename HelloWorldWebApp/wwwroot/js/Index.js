//Js code
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                teamMemberName: newcomerName
            },
            success: function (result) {
                $("#list").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            },
            error: function (err) {
                console.log(err);
            }
        })
    })
});
