module.exports = {
    devServer: {
        proxy: {
            '^/api': {
                target: 'http://localhost:5000',
                changeOrigin: true,
                logLevel: 'debug',
                //pathRewrite: {'^/api': '/'},
            },
         //    '^/person/api': {
         //       target: 'http://localhost:5000/',
         //       changeOrigin: true,
         //       logLevel: 'debug',
         //       pathRewrite: {'^/person/api': '/'},
         //   }
        }
    }
}