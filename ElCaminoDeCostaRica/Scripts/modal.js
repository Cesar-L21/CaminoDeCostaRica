var window = document.getElementById("modal-window1");

//var displayModal = document.getElementById("show-window");
var closeButton = document.getElementsByClassName("close1")[0];

//displayModal.addEventListener('click', open);
closeButton.addEventListener('click', close);

function open() {
    //window.style.display = "block";
    window.className = 'modal2';
    window.onclick = function (event) {
        if (event.target == window) {
            //window.style.display = "none";
            window.className = 'modal1';
        }
    }
}

function close() {
    //window.style.display = "none";
    window.className = 'modal1';
}
