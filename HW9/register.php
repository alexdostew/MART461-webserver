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
    require('mysqliconnection.php');

    // Check connection
    if ($conn->connect_error) {
      die("Connection failed: " . $conn->connect_error);
    }
    echo "Connected successfully <br />";

    $sql = "SELECT * FROM users ORDER BY userid";

    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
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
      while($row = $result->fetch_assoc()) {
          echo "<tr>";
          echo "<td>" . $row["userid"] . "</td>";
          echo "<td>" . $row["username"] . "</td>";
          echo "<td>" . $row["pwd"] . "</td>";
          echo "<td>" . $row["firstname"] . "</td>";
          echo "<td>" . $row["lastname"] . "</td>";
          echo "<td>" . $row["email"] . "</td>";
          echo "</tr>";
      }
      echo "</table>";
    } else {
        echo "0 results";
    }

    // insert data into db if posted
    if($_SERVER["REQUEST_METHOD"] == "POST") {

      $stmt = $conn->prepare("INSERT INTO users (username, pwd, firstname, lastname, email) VALUES (?, ?, ?, ?, ?)");
      $stmt->bind_param("sssss", $username, $pwd, $firstname, $lastname, $email);

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
          $stmt->execute();
          // refresh page to update db
          header('Location: '.$_SERVER['PHP_SELF']);
      }
    }

    $conn->close();
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