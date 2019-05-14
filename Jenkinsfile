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
 }
}
