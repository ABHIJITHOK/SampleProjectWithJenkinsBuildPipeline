pipeline {
    agent any
    stages {
        stage 'Checkout'
			checkout scm
		
		stage('Build') {
            steps {
                bat 'dotnet help'
            }
        }
    }
}