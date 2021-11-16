<html>
  <head>
    <title>Log In</title>
  </head>
  <body>
    <h1>Log In</h1>
    
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

    // check credentials
    if($_SERVER["REQUEST_METHOD"] == "POST") {
  
      require('pdoconnection.php');

      $username = $_POST["username"];
      $pwd = $_POST["pwd"];

      $sql_u = "CALL spSelectUsernamePwd(:user_name, :user_pwd)";
      $stmt = $cn->prepare($sql_u);
      $stmt->bindParam(':user_name', $username, PDO::PARAM_STR);
      $stmt->bindParam(':user_pwd', $pwd, PDO::PARAM_STR);
      
      $stmt->execute();
      $stmt->setFetchMode(PDO::FETCH_ASSOC);

      if ($r = $stmt->fetch()) {
        echo "username + password match";
      } else {
        echo "username + password do not match";
      }
    }
    ?>

    <hr>

    <!-- Sign Up Form -->
    <form action="login.php" method="POST">
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
          <td colspan="2">
              <input type="submit" value="Log In">
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>