//Jenkinsfile (Declarative Pipeline)
pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'echo "Welcome"'
                sh '''
                    echo "The multiline shell steps are working"
                    ls -lah
                '''
            }
        }
    }
}
