/*
* @Creaduo
* Abdurrahman ASLIYÜCE
*/
jQuery(function($){
	$.supersized({
		slides  :  	[ {image : 'images/bg.jpg'} ]
	});
});

$(document).ready(function(){
	$('.loginInput:first').focus();
	$('.loginInput').focusout(function(){
		if(!$(this).val()){
			$('span.validationMessage').text($(this).attr("name") + ' field is required!').show();
		}
	})

	$('#sendForm').click(function(){
		var validationMsg = "Fields are required!";
		
		if(!$(".loginInput").val()){
			alert(validationMsg);
			console.log(validationMsg);
		}else{
			$('#loginForm').submit();
		}
	})
})