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
				script {
					powershell '$currentDate = Get-Date -format "yyyy-MM-dd"'
					powershell 'Write-Output $currentDate'
					powershell 'dotnet vstest "C:/Git/ABHIJITHOK/SampleProjectWithJenkinsBuildPipeline/UnitTestProject1/bin/Debug/netcoreapp2.1/UnitTestProject1.dll" --TestCaseFilter:"(Name=%fullyQualifiedName%)" --logger:"trx;LogFileName=C:\\wagering\\tote\\test\\logs\\${todayDate}\\SampleTestResults_%fullyQualifiedName%.trx"'
				}
			
			}
		}
    }
}