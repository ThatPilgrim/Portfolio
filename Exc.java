import java.sql.*;
//import java.util.Scanner;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

// import java.sql.*;
// import java.util.ArrayList;
// import java.util.List; 

public class Exc extends Application{

	/** public static void main(String[] args) {

		String[] muscleGroups = new String[3]; // it stores the muscle groups the user selects
		String userDifficulty; // stores the difficulty the user selects
		String[] userArray = new String[255]; // stores the selected exercises

		Scanner scanner = new Scanner(System.in);

		// Prompt the user to input 3 muscle groups
		for (int i = 0; i < muscleGroups.length; i++) {
			System.out.print("Enter muscle group " + (i + 1) + ": ");
			muscleGroups[i] = scanner.nextLine();
		}

		// Prompt the user to select a number between 1 and 4
		while (true) {
			System.out.print("Select a difficulty level (1-4): ");
			userDifficulty = scanner.nextLine();

			//Check if the input is valid
			if (userDifficulty.equals("1") || userDifficulty.equals("2") || userDifficulty.equals("3")
					|| userDifficulty.equals("4")) {
				break; // Exit the loop if the input is valid
			} else {
				System.out.println("Invalid input. Please enter a number between 1 and 4.");
			}

		}

		// Close the scanner
		scanner.close();

		// Print the results
		System.out.println("You entered the following muscle groups:");
		for (String muscle : muscleGroups) {
			System.out.println(muscle);
		}
		System.out.println("Selected difficulty level: " + userDifficulty + '\n');

		//userArray = getExercises(muscleGroups, userDifficulty);

		// Print the userArray to verify the results
		//System.out.println("Your exercises are as follows:");
		  for (String exercise : userArray) { if (exercise != null) {
		  System.out.println(exercise); } }
		 
	}*/

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//public class ExerciseApp extends Application {

		private static final String[] MUSCLE_GROUPS = {"Hamstrings", "Triceps", "Biceps", "Glutes", "Core", "Quadriceps"};
		private ComboBox<String> muscleGroupComboBox1;
		private ComboBox<String> muscleGroupComboBox2;
		private ComboBox<String> muscleGroupComboBox3;
		private ComboBox<String> difficultyComboBox;
	
		public static void main(String[] args) {
			launch(args);
		}
	
		@Override
		public void start(Stage primaryStage) {
			primaryStage.setTitle("Exercise Selector");
	
			// Muscle Group ComboBoxes
			muscleGroupComboBox1 = new ComboBox<>();
			muscleGroupComboBox1.getItems().addAll(MUSCLE_GROUPS);
			muscleGroupComboBox1.setPromptText("Select muscle group 1");
	
			muscleGroupComboBox2 = new ComboBox<>();
			muscleGroupComboBox2.getItems().addAll(MUSCLE_GROUPS);
			muscleGroupComboBox2.setPromptText("Select muscle group 2");
	
			muscleGroupComboBox3 = new ComboBox<>();
			muscleGroupComboBox3.getItems().addAll(MUSCLE_GROUPS);
			muscleGroupComboBox3.setPromptText("Select muscle group 3");
	
			// Difficulty ComboBox
			difficultyComboBox = new ComboBox<>();
			difficultyComboBox.getItems().addAll("1", "2", "3", "4");
			difficultyComboBox.setPromptText("Select difficulty level");
	
			// Button to get exercises
			Button getExercisesButton = new Button("Get Exercises");
			getExercisesButton.setOnAction(e -> getExercises());
	
			// Layout
			VBox layout = new VBox(10);
			layout.getChildren().addAll(muscleGroupComboBox1, muscleGroupComboBox2, muscleGroupComboBox3, difficultyComboBox, getExercisesButton);
	
			// Scene
			Scene scene = new Scene(layout, 300, 250);
			primaryStage.setScene(scene);
			primaryStage.show();
		}
	
		private void getExercises() {
			String[] muscleGroups = {
					muscleGroupComboBox1.getValue(),
					muscleGroupComboBox2.getValue(),
					muscleGroupComboBox3.getValue()
			};
			String userDifficulty = difficultyComboBox.getValue();
	
			if (muscleGroups[0] == null || muscleGroups[1] == null || muscleGroups[2] == null || userDifficulty == null) {
				showAlert("Error", "Please select all muscle groups and difficulty level.");
				return;
			}
	
			String[] exercises = getExercises(muscleGroups, userDifficulty);
			showExercises(exercises);
		}
	
		private void showAlert(String title, String message) {
			Alert alert = new Alert(Alert.AlertType.ERROR);
			alert.setTitle(title);
			alert.setHeaderText(null);
			alert.setContentText(message);
			alert.showAndWait();
		}
    private void showExercises(String[] exercises) {
        StringBuilder result = new StringBuilder("Your exercises are as follows:\n");
        for (String exercise : exercises) {
            if (exercise != null) {
                result.append(exercise).append("\n");
            }
        }

        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Exercises");
        alert.setHeaderText(null);
        alert.setContentText(result.toString());
        alert.showAndWait();
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	public static String[] getExercises(String[] muscleGroups, String userDifficulty) {
		String url = "jdbc:mysql://localhost:3306/exercise"; // the URL to the database you're connecting to
		String username = "root"; // the username of the MySQL Workbench profile or whatever
		String password = "Password"; // the password to that user
		String muscleGroup; //String to store the current muscle group
		String[] excArray = new String[55]; // Array that stores the selected exercises based on the muscle group
		String temporaryExercise;
		String[] userArray = new String[255]; // stores the exercises based on its difficulty and is returned to the user

		try {
			Class.forName("com.mysql.cj.jdbc.Driver"); // this loads the MySQL JDBC driver

			Connection connection = DriverManager.getConnection(url, username, password); // Creating a connection to
																							// MySQL Workbench

			int j = 0; // index for userArray

			for (int e = 0; e < muscleGroups.length; e++) {

				if (j > 1) { // Adds a newline character between each result set of exercises for each muscle
					userArray[j] = "\n";
					j++;
				}
				muscleGroup = muscleGroups[e]; // it stores the current muscle group the user selected
				userArray[j] = "The exercises for the " + muscleGroup + " muscle is as follows:";
				j++;
				//	 for (String exercise : userArray) { if (exercise != null) {
				//	  System.out.println(exercise); } }
				
				String query = "SELECT exercise FROM workouts WHERE Muscle = ?"; // stores the SQL query we want to run
																					// with a placeholder
				PreparedStatement preparedStatement = connection.prepareStatement(query);
				preparedStatement.setString(1, muscleGroup); // fills the placeholder with whatever is stored in
																// muscleGroup

				ResultSet resultSet = preparedStatement.executeQuery(); // executes the query and stores the result in
																		// resultSet

				// Clear excArray and store the returned values
				for (int k = 0; k < excArray.length; k++) {
					excArray[k] = null;
				}

				int g = 0;
				while (resultSet.next()) {
					excArray[g] = resultSet.getString(1);
					// System.out.println(excArray[g]);
					g++;
				}

				// Loop through the excArray to get exercises for their difficulty and store in
				// userArray
				int i = 0;
				while (i < excArray.length && excArray[i] != null) {
					temporaryExercise = excArray[i]; // move each item from excArray to a temporaryExercise

					// use temporaryExercise and a prepared statement to query the db for its
					// difficulty
					String query2 = "SELECT difficulty FROM difficulty WHERE Exercise = ?";
					PreparedStatement preparedStatement2 = connection.prepareStatement(query2);
					preparedStatement2.setString(1, temporaryExercise); // fills the placeholder with whatever is stored
																		// in temporaryExercise
					ResultSet resultSet2 = preparedStatement2.executeQuery();

					// check whether the difficulty is the same as the user selection
					if (resultSet2.next()) { // Move the cursor to the first row
						if (resultSet2.getString(1).equals(userDifficulty)) {
							userArray[j] = temporaryExercise; // if yes, store temporaryExercise to userArray
							j++;
						}
					}
					i++;
				}
				
			}

			connection.close();

		} catch (Exception e) {
			System.out.println(e);
		} // catch

		return userArray;
	}// getexercise
//}


}