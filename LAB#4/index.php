<?php
session_start();
require_once("bd_connect.php");
 
function loginForm(){
    echo'
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Free Chat</title>
<link type="text/css" rel="stylesheet" href="style.css" />
</head>
<center><font size="5" color="black">Welcome to free Chat!</font></center><br>
    <div id="loginform">
    <form action="index.php" method="post">
        <p><font color="white">Please enter your name to continue:</font></p>
        <label for="name"><font color="white">Name:</font></label>
        <input type="text" name="name" id="name" />
        <input type="submit" name="enter" id="enter" value="Enter" />
    </form>
    </div>
    ';
}
 
if(isset($_POST['enter'])){
    if($_POST['name'] != ""){
        $_SESSION['name'] = stripslashes(htmlspecialchars($_POST['name']));
    }
    else{
        echo '<span class="error">Please select your nickname</span>';
    }
}
if(isset($_GET['logout'])){
    mysql_query("DELETE from `online` WHERE `nick`='".$_SESSION['name']."'");
    session_destroy();
    header("Location: index.php");
}
if(!isset($_SESSION['name'])){
    loginForm();
}
else{
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Free Chat</title>
<link type="text/css" rel="stylesheet" href="style.css" />
</head>
<center><font size="5" color="black">Enjoy free Chat!</font></center><p class="logout"><a id="exit" href="#"> (Exit Chat)</a><br><br>
<div id="wrapper">
    <div id="menu">
        <p class="welcome"><font color="white">Welcome, <b><?php echo $_SESSION['name']; ?></b></font></p>

        <div style="clear:both"></div>
    </div>    
    <div id="chatbox"></div>
    <form name="message" action="">
        <input name="usermsg" type="text" id="usermsg" size="63" />
        <input name="submitmsg" type="submit"  id="submitmsg" value="Say" />
    </form>
    <br><font color="white">
Now online:
</font>
<br><br>
<div id="onlinebox"></div>
</div>
<br>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js">
</script>
<?php
}
?>
</script>
<script type="text/javascript">
$(window).unload(function(){
$.post("enter.php", {text: 'logout'}); 
}) 
$(document).ready(function(){
    loadLog();
    $.post("enter.php", {text: 'login'});  
	$("#exit").click(function(){
		var exit = confirm("Are you sure you want to end session?");
		if(exit==true){window.location = 'index.php?logout=true';}		
	});
   $(window).on('beforeunload', function(){
          $.post("enter.php", {text: 'logout'}); 
   });
});
$("#submitmsg").click(function(){	
		var clientmsg = $("#usermsg").val();
		$.post("post.php", {text: clientmsg});				
		$("#usermsg").attr("value", "");
		return false;
	});

function loadLog(){      
        var oldscrollHeight = $("#chatbox").attr("scrollHeight") - 20;
        $.ajax({ 
        type: 'GET', 
        url: 'log.php', 
        data: { num: '30' }, 
        dataType: 'json',
        success: function (data) { 
            $('#chatbox').html('');
            $.each(data, function(index, element) {
                $('#chatbox').prepend("<div class='msgln'>("+element.datetime+") <b>"+element.nick+"</b>: "+element.msg+"<br></div>");
            });
            var newscrollHeight = $("#chatbox").attr("scrollHeight") - 20;
                if(newscrollHeight > oldscrollHeight){
                    $("#chatbox").animate({ scrollTop: newscrollHeight }, 'normal');
                }               
        }
    });
    }
    function loadOnline(){      
        var oldscrollHeight = $("#onlinebox").attr("scrollHeight") - 20;
        $.ajax({ 
        type: 'POST', 
        url: 'enter.php', 
        data: { text: 'get' }, 
        dataType: 'json',
        success: function (data) { 
            $('#onlinebox').html('');
            $.each(data, function(index, element) {
                $('#onlinebox').prepend("<div class='msgln'><font color='red'><b>"+element.nick+"</b></font><br></div>");
            });
            var newscrollHeight = $("#onlinebox").attr("scrollHeight") - 20;
                if(newscrollHeight > oldscrollHeight){
                    $("#onlinebox").animate({ scrollTop: newscrollHeight }, 'normal');
                }               
        }
    });
    }
	setInterval (loadLog, 500);
    setInterval (loadOnline, 1500);
</script>
</body>
</html>

