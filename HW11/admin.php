<html>
  <head>
    <title>Admin</title>
  </head>
  <body>
    <?php
        // open connection
        require('mysqliconnection.php');

        // set selected user
        if(isset($_POST["ddlUsers"])){
            $user=$_POST["ddlUsers"];
        }

        
        // insert new user
        if(isset($_POST["insertUser"])) {
            if(isset($user)) {
                if($_SERVER["REQUEST_METHOD"] == "POST") {

                    require('pdoconnection.php');

                    $username = $_POST["username"];

                    $sql_u = "CALL spSelectUsername(:user_name)";
                    $stmt = $cn->prepare($sql_u);
                    $stmt->bindParam(':user_name', $username, PDO::PARAM_STR);
                    
                    $stmt->execute();
                    $stmt->setFetchMode(PDO::FETCH_ASSOC);

                    if ($r = $stmt->fetch()) {
                        echo "username already taken";
                    } else {
                        $pwd = $_POST["pwd"];
                        $firstname = $_POST["fName"];
                        $lastname = $_POST["lName"];
                        $email = $_POST["email"];

                        $sql = "CALL spInsertUser(:username, :pwd, :firstname, :lastname, :email)";
                        $stmt = $cn->prepare($sql);
                        $stmt->bindParam(':username', $username, PDO::PARAM_STR);
                        $stmt->bindParam(':pwd', $pwd, PDO::PARAM_STR);
                        $stmt->bindParam(':firstname', $firstname, PDO::PARAM_STR);
                        $stmt->bindParam(':lastname', $lastname, PDO::PARAM_STR);
                        $stmt->bindParam(':email', $email, PDO::PARAM_STR);
                        $stmt->execute();
                        $stmt->closeCursor();
                        // refresh page to update db
                        header('Location: '.$_SERVER['PHP_SELF']);
                    }
                }
            }
        }

        // update selected user
        if(isset($_POST["updateUser"])) {
            if(isset($user)) {
                if($_SERVER["REQUEST_METHOD"] == "POST") {
                    require('pdoconnection.php');
                    $username = $_POST["username"];
                    $sql_u = "CALL spSelectUsername(:user_name)";
                    $stmt = $cn->prepare($sql_u);
                    $stmt->bindParam(':user_name', $username, PDO::PARAM_STR);
                    
                    $stmt->execute();
                    $stmt->setFetchMode(PDO::FETCH_ASSOC);

                    $count = 0;
                    while ($r = $stmt->fetch()) {
                        $count += 1;
                        
                    }

                    if ($count > 1) {
                        echo "username already taken";
                    } else {
                        $pwd = $_POST["pwd"];
                        $firstname = $_POST["fName"];
                        $lastname = $_POST["lName"];
                        $email = $_POST["email"];
                        if ($username == "") {
                            echo "enter a username";
                        } else if ($pwd == "") {
                            echo "enter a password";
                        } else if ($firstname == "") {
                            echo "enter a first name";
                        } else if ($lastname == "") {
                            echo "enter a last name";
                        } else if ($email == "") {
                            echo "enter an email";
                        } else {
                            $sql = "CALL spUpdateUser(:user_name, :user_pwd, :first_name, :last_name, :user_email, :user_id)";
                            $stmt = $cn->prepare($sql);
                            $stmt->bindParam(':user_name', $username, PDO::PARAM_STR);
                            $stmt->bindParam(':user_pwd', $pwd, PDO::PARAM_STR);
                            $stmt->bindParam(':first_name', $firstname, PDO::PARAM_STR);
                            $stmt->bindParam(':last_name', $lastname, PDO::PARAM_STR);
                            $stmt->bindParam(':user_email', $email, PDO::PARAM_STR);
                            $stmt->bindParam(':user_id', $user, PDO::PARAM_INT);
                            $stmt->execute();
                            $stmt->closeCursor();
                        }
                    }
                }
            }
        }

        // delete user
        if(isset($_POST["deleteUser"])) {
            if(isset($user)) {
                if($_SERVER["REQUEST_METHOD"] == "POST") {
                    require('pdoconnection.php');
                    $sql = "CALL spDeleteWithId(:id)";
                    $stmt = $cn->prepare($sql);
                    $stmt->bindParam(':id', $user, PDO::PARAM_INT);
                    $stmt->execute();
                    $stmt->closeCursor();
                }
            }
        }
    ?>
    
    <h1>Admin</h1>
    <a href="register.php">Register</a>
    <a href="login.php">Log In</a> <br/>

    <hr>

    <!-- Sign Up Form -->
    <form action="" method="POST">
        <select name="ddlUsers" onchange="this.form.submit()">
            <option value="" disable selected>Choose user</option>
            <?php
                require('pdoconnection.php');
                try {
                    $sql = "CALL spSelectAll()";
                    $q = $cn->query($sql);
                    $q->setFetchMode(PDO::FETCH_ASSOC);
                } catch (PDOException $e) {
                    die("Error occurred:" . $e->getMessage());
                }

                if ($r = $q->fetch()) {
                    while($r = $q->fetch()) {
                        echo "<option value='" . $r["userid"] . "'"; 
                        if (isset($user)) {
                            if ($r["userid"] == $user) {
                                echo "selected";
                                $username = $r["username"];
                                $pwd = $r["pwd"];
                                $firstname = $r["firstname"];
                                $lastname = $r["lastname"];
                                $email = $r["email"];
                            }
                        }
                        echo ">" . $r["userid"] . " " . $r["username"] . "</option>";
                    }
                } 
            ?>
        </select>
        <hr>
      <table>
        <tr>
          <td>
              Username:
          </td>
          <td>
              <input type="text" name="username" value="<?php if (isset($username)) {echo $username;} ?>">
          </td>
        </tr>
        <tr>
          <td>
              Password:
          </td>
          <td>
              <input type="text" name="pwd" value="<?php if (isset($pwd)) {echo $pwd;} ?>">
          </td>
        </tr>
        <tr>
          <td>
              First Name:
          </td>
          <td>
              <input type="text" name="fName" value="<?php if (isset($firstname)) {echo $firstname;} ?>">
          </td>
        </tr>
        <tr>
          <td>
              Last Name:
          </td>
          <td>
              <input type="text" name="lName" value="<?php if (isset($lastname)) {echo $lastname;} ?>">
          </td>
        </tr>
        <tr>
          <td>
              Email:
          </td>
          <td>
              <input type="text" name="email" value="<?php if (isset($email)) {echo $email;} ?>">
          </td>
        </tr>
          <td colspan="2">
              <input type="submit" value="Insert New User" name="insertUser">

              <input type="submit" value="Update Selected User" name="updateUser">

              <input type="submit" value="Delete Selected User" name="deleteUser">
          </td>
        </tr>
      </table>
    </form>
    <?php 
        //close connection
        $conn->close(); 
    ?>
  </body>
</html>