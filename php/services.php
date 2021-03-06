<?php
class Services
{
	const HOST = "localhost";
	const USER = "root";
	const PASS = "";
	const DB = "test";
	
	private static $instance;
	
	public static function GetInstance() 
	{	
		if(!self::$instance) self::$instance = new self();		
	
		return self::$instance;	
	}	
	
	public function AddNewUser()
	{
		$con = mysqli_connect(self::HOST, self::USER, self::PASS, self::DB);
		
		if (mysqli_connect_errno()) return false;

		$result = mysqli_query($con, "INSERT INTO users (email, password) VALUES ('richard.wallier@nave.org.br', 'NAVETing@123')");
		
		if(mysqli_num_rows($result) > 0) 
		{
			$row = mysqli_fetch_assoc($result);
		}
		else 
		{
			$row = "";		
		}
		
		mysqli_close($con);
		
		return $row === "" ? false : $row["value"];
	}
	
	public function SetHighscore($highscore)
	{
		$con = mysqli_connect(self::HOST, self::USER, self::PASS, self::DB);
	
		if (mysqli_connect_errno()) return false;
	
		mysqli_query($con, "UPDATE highscore SET value = '$highscore' WHERE id = 0");
		
		mysqli_close($con);
	
		return true;
	}
}
?>