Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any
    stages {
		stage 'Checkout'
			checkout scm
		
		stage('Build') {
            steps {
				bat 'nuget restore SampleProjectWithJenkinsBuildPipeline.sln'
				bat "\"${tool 'MSBuild'}\" SampleProjectWithJenkinsBuildPipeline.sln"
            }
        }

		stage 'Archive'
			archive 'MyConsoleApp1/bin/Release/**'
    }
}