$(document).ready(function() {
	$('#textBox').keyup(function() {
		if($(this).val() === 'hello') {
			alert('Hello, World!');
		}
	});

	var clicks = 0;

	$('input[value="I should be red and on the right side"]').click(function(e) {
   		e.preventDefault();
   		clicks++;
   		$('#hover2 > ul').append('<li>' + clicks + '</li>');
	});
});