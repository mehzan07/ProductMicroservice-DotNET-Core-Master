//Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = "1"
    }
echo 'Checkout'
    stages {
        stage('Checkout') {
            steps {
                script {
                    checkout scm
                }
            }
        }
echo 'Starting Restore'
        stage('Restore') {
            steps {
                script {
                    bat "dotnet restore ${env.WORKSPACE}/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
                }
            }
        }
echo 'Starting Build'
        stage('Build') {
            steps {
                script {
                    bat "dotnet build ${env.WORKSPACE}/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj"
                }
            }
        }
echo 'Starting Test'
        stage('Test') {
            steps {
                script {
                    bat "dotnet test ${env.WORKSPACE}/ProductMicroservicesTest/ProductMicroserviceTest.csproj"
                }
            }
        }
echo 'Starting Publish'
        stage('Publish') {
            steps {
                script {
                    bat "dotnet publish ${env.WORKSPACE}/ProductMicroservice/ProductMicroservice/ProductMicroservice.csproj -c Release -o ${env.WORKSPACE}/publish"
                }
            }
        }
echo 'Starting Deploy'
        stage('Deploy') {
            steps {
                // Add your deployment steps here
                // e.g., deploy to a server, push to a container registry, etc.
            }
        }
    }

    post {
        success {
            echo 'Build successful - Add any additional success steps here'
        }
        failure {
            echo 'Build failed - Add any additional failure steps here'
        }
    }
}
