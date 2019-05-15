pipeline {
    
	agent any
	
	parameters {
		string(name: 'fullyQualifiedName', defaultValue: 'TestMethod1', description: 'Test Case Name.')
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

		stage('Clean') {
			steps {
				powershell 'dotnet clean'
			}
		}

		stage('Build') {
            steps {
				powershell 'dotnet build --configuration Release'
            }
        }

		stage('Test') {
			steps {
				bat '''
				    set > env.txt
					for (String i : readFile('env.txt').split("\r?\n")) {
						println i
					}
					'''
				
				powershell '''
					$currentDate = Get-Date -UFormat "%Y-%m-%d"
					$testCaseFilter = 'TestMethod2'
					$currentWorkSpace = $env:WORKSPACE
					Write-Host 'My Workspace is ${currentWorkSpace}'
					Write-Host 'Starting test execution.'
					dotnet vstest "C:/Git/ABHIJITHOK/SampleProjectWithJenkinsBuildPipeline/UnitTestProject1/bin/Debug/netcoreapp2.1/UnitTestProject1.dll" --TestCaseFilter:"(Name=${testCaseFilter})" --logger:"trx;LogFileName=C:\\wagering\\tote\\test\\logs\\${currentDate}\\SampleTestResults_${testCaseFilter}.trx"
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