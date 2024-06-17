function myMove() {
	var elem = document.getElementById("movingText");
	var pos = 0;
	var direction = 1; // 1 for right, -1 for left

	function frame() {
		if (pos >= 2000 || pos < 0) {
			direction *= -1; // Change direction
		}
		pos += direction;
		elem.style.left = pos + 'px';
		requestAnimationFrame(frame); // Recursively call frame for smoother animation
	}

	frame();
}