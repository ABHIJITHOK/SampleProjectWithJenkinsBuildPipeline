pipeline {
    agent any
    stages {
        stage ('Checkout') {
			steps {
				checkout scm
			}
		}

		stage('Build') {
            steps {
                bat 'dotnet help'
				bat 'dotnet build --configuration Release'
            }
        }
    }
}

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
				bat "dotnet restore"
			}
		}

		stage('Clean') {
			steps {
				bat 'dotnet clean'
			}
		}

		stage('Build') {
            steps {
				bat 'dotnet build --configuration Release'
            }
        }

		stage('Test') {
			steps {
				bat 'echo %fullyQualifiedName%'
				echo "Running ${env.BUILD_ID} on ${env.JENKINS_URL}"
				script {
					def now = new Date().format("yyyy-MM-dd", TimeZone.getTimeZone('UTC'))
					println now
					bat 'echo %Date:~0,3%day'
					powershell '$currentDate = Get-Date -format "yyyy-MM-dd"'
					powershell 'Write-Output "Hello, World!"'
					powershell 'Write-Output $currentDate'
					def todayDate = powershell(returnStdout: true, script: 'Get-Date -format "yyyy-MM-dd"')
					println todayDate
					powershell 'dotnet vstest "C:/Git/ABHIJITHOK/SampleProjectWithJenkinsBuildPipeline/UnitTestProject1/bin/Release\netcoreapp2.1/UnitTestProject1.dll" --TestCaseFilter:"(Name=%fullyQualifiedName%)" --logger:"trx;LogFileName=C:\\wagering\\tote\\test\\logs\\${todayDate}\\SampleTestResults_%fullyQualifiedName%.trx"'
				}
			
			}
		}
    }
}