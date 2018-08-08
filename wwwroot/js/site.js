// Write your JavaScript code.
$(document).ready(function () {
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });
    $('#add-item-button').on('click', addItem);
    $('#add-user').on('click', addUser);
    $('#remove-user').on('click', removeUser);
});
function addItem() {
    $('#add-item-error').hide();
    var newTitle = $('#add-item-title').val();

    $.post('/Todo/AddItem', { title: newTitle }, function () {
        window.location = '/Todo';
    })
        .fail(function (data) {
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
                $('#add-item-error').text(firstError);
                $('#add-item-error').show();
            }
        });
}
function markCompleted(checkbox) {
    checkbox.disabled = true;

    $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
        var row = checkbox.parentElement.parentElement;
        $(row).addClass('done');
    });
}
function addUser() {
    var newName = $('#add-user-name').val();
    var newEmail = $('#add-user-email').val();
    $.post('/User/AddUser', { name: newName, Email: newEmail }, function () {
        window.location = '/User';
    });
}
function removeUser() {

    var userId = $("[data-id]").val();

    $.post('/User/DeleteUser', { id: userId }, function () {
            window.location = '/User';
        });

 
        
    
}