//Js code
$(document).ready(function () {
    // see https://api.jquery.com/click/

    $('#nameField').on('keyup', function () {
        var empty = false;

        $('#nameField').each(function () {
            empty = $(this).val().length == 0;
        });

        if (empty)
            $('#createMember').attr('disabled', 'disabled');
        else
            $('#createMember').attr('disabled', false);
    });

    $("#createMember").click(function () {
        var newcomerName = $("#nameField").val();
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "name": newcomerName
            },
            success: function (result) {
                $("#list").append(`
                <li id=${result.id} class="member">
                    <span class="name">${result.name}</span>
                    <span id="deleteMember" onclick="deleteMember();" class="delete fa fa-remove"></span>
                    <span class="pencil fa fa-pencil"></span>
                </li>`

                );
                $("#nameField").val("");
                $('#createMember').prop('disabled', true);
            },
            error: function (err) {
                console.log(err);
            }
        })
    })
});


function clearNameField() {
    $("#nameField").val("");
    $('#createMember').prop('disabled', true);
};

function deleteMember() {
    const parentElement = $("#deleteMember").parent()
    var id = parentElement.attr('id');

    $.ajax({
        method: "DELETE",
        url: `/Home/DeleteTeamMember?id=${id}`,
        success: function (result) {
            parentElement.remove();
        },
        error: function (err) {
            console.log(err);
        }
    })
}
