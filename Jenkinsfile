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