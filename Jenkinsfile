pipeline {
 agent any
 environment {
  dotnet = 'C:\Program Files\dotnet\dotnet.exe'
 }
 stages {
  stage('Checkout') {
   steps {
    git credentialsId: 'ABHIJITHOK', url: 'https://github.com/ABHIJITHOK/SampleProjectWithJenkinsBuildPipeline', branch: 'master'
   }
  }
  stage('Restore PACKAGES') {
   steps {
    bat "dotnet restore --configfile NuGet.Config"
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
  stage('Pack') {
   steps {
    bat 'dotnet pack --no-build --output nupkgs'
   }
  }
 }
}
