// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function myMove() {
    var elem = document.getElementById("movingText");
    var pos = 0;
    var direction = 1; // 1 for right, -1 for left

    function frame() {
        if (pos >= 1700 || pos < 0) {
            direction *= -1; // Change direction
        }
        pos += direction;
        elem.style.left = pos + 'px';
        requestAnimationFrame(frame); // Recursively call frame for smoother animation
    }

    frame();
}

window.onload = function () {
    myMove();
    changeImg();
}; // Call myMove when the page loads