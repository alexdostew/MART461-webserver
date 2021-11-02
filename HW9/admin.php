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

                    echo "insert user <br/>";

                    $username = $_POST["username"];
                    $pwd = $_POST["pwd"];
                    $firstname = $_POST["fName"];
                    $lastname = $_POST["lName"];
                    $email = $_POST["email"];

                    $sql_u = "SELECT * FROM users WHERE username='$username'";
                    $res_u = $conn->query($sql_u);
                    
                    if (mysqli_num_rows($res_u) > 0) {
                        echo "username already taken";
                    } else {
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
                            $stmt = $conn->prepare("INSERT INTO users (username, pwd, firstname, lastname, email) VALUES (?, ?, ?, ?, ?)");
                            $stmt->bind_param("sssss", $username, $pwd, $firstname, $lastname, $email);
                            $stmt->execute();
                        }
                    } 
                }
            }
        }

        // update selected user
        if(isset($_POST["updateUser"])) {
            if(isset($user)) {
                if($_SERVER["REQUEST_METHOD"] == "POST") {
              
                    $username = $_POST["username"];
                    $pwd = $_POST["pwd"];
                    $firstname = $_POST["fName"];
                    $lastname = $_POST["lName"];
                    $email = $_POST["email"];

                    $sql_u = "SELECT * FROM users WHERE username='$username'";
                    $res_u = $conn->query($sql_u);
                    if (mysqli_num_rows($res_u) > 0) {
                        echo "username already taken";
                    } else {
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
                            $sql = "UPDATE users SET username='$username', pwd='$pwd', firstname='$firstname', lastname='$lastname', email='$email' WHERE userid='$user'";
                            if ($conn->query($sql) === TRUE) {
                                echo "Record updated successfully";
                              } else {
                                echo "Error updating record: " . $conn->error;
                              }
                        }
                    }
                }
            }
        }

        // delete user
        if(isset($_POST["deleteUser"])) {
            if(isset($user)) {
                if($_SERVER["REQUEST_METHOD"] == "POST") {
              
                    $sql = "DELETE FROM users WHERE userid='$user'";
                    if ($conn->query($sql) === TRUE) {
                    echo "Record deleted successfully";
                    } else {
                    echo "Error deleting record: " . $conn->error;
                    }
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
                

                $sql = "SELECT * FROM users";

                $result = $conn->query($sql);

                if ($result->num_rows > 0) {
                    // output data of each row
                    while($row = $result->fetch_assoc()) {
                        echo "<option value='" . $row["userid"] . "'"; 
                        if (isset($user)) {
                            if ($row["userid"] == $user) {
                                echo "selected";
                                $username = $row["username"];
                                $pwd = $row["pwd"];
                                $firstname = $row["firstname"];
                                $lastname = $row["lastname"];
                                $email = $row["email"];
                            }
                        }
                        echo ">" . $row["userid"] . " " . $row["username"] . "</option>";
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