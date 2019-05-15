pipeline {
    
	agent any
	
	parameters {
		string(name: 'fullyQualifiedName', defaultValue: 'TestMethod1', description: 'Test Case Name.')
		string(name: 'someotherparam', defaultValue: 'somevalue', description: 'Test Case Name.')
	}

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

					$currentLocation = Get-Location
					$currentDate = Get-Date -UFormat "%Y-%m-%d"
					$testCaseFilter = 'TestMethod2'
					Write-Host 'Starting test execution.'					
					dotnet vstest "${currentLocation}\\UnitTestProject1\\bin\\Release\\netcoreapp2.1\\UnitTestProject1.dll" --TestCaseFilter:"(Name=${testCaseFilter})" --logger:"trx;LogFileName=C:\\wagering\\tote\\test\\logs\\${currentDate}\\SampleTestResults_${testCaseFilter}.trx"
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