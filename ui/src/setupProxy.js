const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    //"/students",
    //"/checkin"
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7003',
        secure: false
    });

    app.use(appProxy);
};
