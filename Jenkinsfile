pipeline {
    
	agent any
	
    stages {
        stage ('Checkout') {
			steps {
				checkout scm
			}
		}

		stage('Restore PACKAGES') {
			steps {
				powershell "dotnet restore"
			}
		}

		stage('Clean and Build') {
            steps {
				powershell '''
					dotnet clean
					dotnet build --configuration Release
				'''
            }
        }

		stage('Run Tests') {
			steps {
				powershell '''
					$VAR_A = 'test'
					$fullyQualifiedName = 'TestMethod1'
					Write-Host "My result: '$VAR_A'"	
					Write-Host "Test Name: '$fullyQualifiedName'"
					$currentLocation = Get-Location
					$currentDate = Get-Date -UFormat "%Y-%m-%d"
					$testCaseFilter = 'TestMethod2'
					Write-Host 'Starting test execution.'
					dotnet vstest "${currentLocation}\\UnitTestProject1\\bin\\Release\\netcoreapp2.1\\UnitTestProject1.dll" --TestCaseFilter:"(Name=${fullyQualifiedName})" --logger:"trx;LogFileName=C:\\wagering\\tote\\test\\logs\\${currentDate}\\SampleTestResults_${fullyQualifiedName}.trx"
					Write-Host 'Finished test execution.'
				'''
			}
		}

    }

	/*Cleaning up and notifications*/
	post {
		always {
				echo 'One way or another, I have finished'
				deleteDir() /* clean up our workspace */
		}
		success {
				echo 'I succeeeded!'
		}
		unstable {
				echo 'I am unstable :/'
		}
		failure {
				echo 'I failed :('
		}
		changed {
				echo 'Things were different before...'
		}
	}

}