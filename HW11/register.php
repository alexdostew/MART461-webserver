<html>
  <head>
    <title>Register</title>
  </head>
  <body>
    <h1>Sign Up</h1>
    <a href="admin.php">Admin</a>
    <a href="login.php">Log In</a> <br/>
    
    <?php
    // open connection
    require('pdoconnection.php');

    try {
      $sql = "CALL spSelectAll()";
      $q = $cn->query($sql);
      $q->setFetchMode(PDO::FETCH_ASSOC);
    } catch (PDOException $e) {
      die("Error occurred:" . $e->getMessage());
    }

    if ($r = $q->fetch()) {
      // output data of each row
      echo "<table border='1'>
      <tr>
      <th>User ID</th>
      <th>Username</th>
      <th>Password</th>
      <th>First Name</th>
      <th>Last Name</th>
      <th>Email</th>
      </tr>";
      while($r = $q->fetch()) {
          echo "<tr>";
          echo "<td>" . $r["userid"] . "</td>";
          echo "<td>" . $r["username"] . "</td>";
          echo "<td>" . $r["pwd"] . "</td>";
          echo "<td>" . $r["firstname"] . "</td>";
          echo "<td>" . $r["lastname"] . "</td>";
          echo "<td>" . $r["email"] . "</td>";
          echo "</tr>";
      }
      echo "</table>";
    } else {
        echo "0 results";
    }

    // insert data into db if posted
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
    ?>

    <hr>

    <!-- Sign Up Form -->
    <form action="register.php" method="POST">
      <table>
        <tr>
          <td>
              Username:
          </td>
          <td>
              <input type="text" name="username" required>
          </td>
        </tr>
        <tr>
          <td>
              Password:
          </td>
          <td>
              <input type="text" name="pwd" required>
          </td>
        </tr>
        <tr>
          <td>
              First Name:
          </td>
          <td>
              <input type="text" name="fName" required>
          </td>
        </tr>
        <tr>
          <td>
            Last Name:
          </td>
          <td>
            <input type="text" name="lName" required>
          </td>
        </tr>
        <tr>
          <td>
            Email:
          </td>
          <td>
            <input type="text" name="email" required>
          </td>
        </tr>
        <tr>
          <td colspan="2">
              <input type="submit" value="Sign Up">
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>