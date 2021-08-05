//Js code
$(document).ready(function () {
    // see https://api.jquery.com/click/

    $('#nameField').on('keyup', function () {
        var empty = false;

        $('#nameField').each(function () {
            empty = $(this).val().length == 0;
        });

        if (empty)
            $('#createButton').attr('disabled', 'disabled');
        else
            $('#createButton').attr('disabled', false);
    });

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#list").append(`<li>${result}

                 <span class="name">${newcomerName}</span>
                 <span  class="delete fa fa-remove" onclick="deleteTeamMember"></span>
                 <span  class="pencil fa fa-pencil"></span>

                                            </li>`);
                $("#nameField").val("");
                $('#createButton').prop('disabled', true);
            },
            error: function (err) {
                console.log(err);
            }
        })
    })

    $("#clear").click(function () {
        $("#nameField").val("");
        $('#createButton').prop('disabled', true);
    });

    $("#deleteField").click(function () {
        var newcomerName = $("memberField").val();
        $.ajax({
            method: "POST",
            url: "/Home/DeleteTeamMember",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#list").remove(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            },
            error: function (err) {
                console.log(err);
            }
        })
    })
});
