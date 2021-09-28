<html>
    <head>
        <title>Login!</title>
    </head>
    <body>
        <form method="GET">
        <table>
            <tr>
                <td>
                    Username:
                </td>
                <td>
                    <input type="text" name="username">
                </td>
            </tr>
            <tr>
                <td>
                    Password:
                </td>
                <td>
                    <input type="text" name="pwd">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="submit" value="Submit">
                </td>
            </tr>
        </table>
        </form>

        <?php

        //check if query string has been created
        if(isset($_GET["username"]) && isset($_GET["pwd"])){
            

            // set variable to query string
            $username = $_GET["username"];
            $pwd = $_GET["pwd"];

            // print out data
            echo("<h1>Query Strings</h1>");
            echo("<p>Username: " . $username . "</p>");
            echo("<p>Password: " . $pwd . "</p>");


            // create variables for cookies
            $cookie_name = "username";
            $cookie_value = $username;

            $cookie_pwd = "pwd";
            $cookie_pwdValue = $pwd;

            //create cookies
            setcookie($cookie_name, $cookie_value, time() + (86400 * 30), "/");
            setcookie($cookie_pwd, $cookie_pwdValue, time() + (86400 * 30), "/");


            //check if cookies have been created
            if(!isset($_COOKIE[$cookie_name]) && !isset($_COOKIE[$cookie_pwd])){
                echo("<h1>Cookies not set</h1>");
            } else {
                echo("<h1>Cookies</h1>");
                echo("<p>Username: " . $_COOKIE[$cookie_name] . "</p>");
                echo("<p>Password: " . $_COOKIE[$cookie_pwd] . "</p>");
            }

            session_start();

            $_SESSION["username"] = $username;
            $_SESSION["pwd"] = $pwd;


            echo("<h1>Session</h1>");
            print_r($_SESSION);
            
        }

        

        
        ?>
    </body>
</html>