<html>
  <head>
    <title>Log In</title>
  </head>
  <body>
    <h1>Log In</h1>
    
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

    // check credentials
    if($_SERVER["REQUEST_METHOD"] == "POST") {
  
        $username = $_POST["username"];
        $pwd = $_POST["pwd"];
  
        $sql_u = "SELECT * FROM users WHERE username='$username' AND pwd='$pwd'";
        $res_u = $conn->query($sql_u);
        
        if (mysqli_num_rows($res_u) > 0) {
            echo "successful login";
        } else {
            echo "username and password do not match";
        }
      }

    $conn->close();
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