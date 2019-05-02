Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any
    stages {
		stage('Build') {
            steps {
				bat 'nuget restore SampleProjectWithJenkinsBuildPipeline.sln'
				bat "\"${tool 'MSBuild'}\" SampleProjectWithJenkinsBuildPipeline.sln"
            }
        }

    }
}