﻿Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any
    stages {
		stage 'Checkout'
			checkout scm
		
		stage('Build') {
            steps {
				bat 'Comments'
				bat 'nuget restore SampleProjectWithJenkinsBuildPipeline.sln'
				bat "\"${tool 'MSBuild'}\" SampleProjectWithJenkinsBuildPipeline.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            }
        }

		stage 'Archive'
			archive 'MyConsoleApp1/bin/Release/**'
    }
}