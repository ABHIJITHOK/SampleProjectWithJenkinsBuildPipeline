﻿pipeline {
    agent any
    stages {
			stage 'Checkout'
				checkout scm

			stage 'Build' {
				steps {
						bat 'nuget restore SampleProjectWithJenkinsBuildPipeline.sln'
						bat "\"${tool 'MSBuild'}\" SampleProjectWithJenkinsBuildPipeline.sln /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
				}
			}

			stage 'Archive'
				archive 'ConsoleApp2/bin/Release/**'
	}
}