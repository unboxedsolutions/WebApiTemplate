const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const passport = require('passport');
const cors = require('cors');
const passportJWT = require("passport-jwt");
const ExtractJWT = passportJWT.ExtractJwt;
const JWTStrategy   = passportJWT.Strategy;
const BearerStrategy = require('passport-http-bearer').Strategy;
const jwt = require('jsonwebtoken');
const test = require('./routes/test');

passport.use(new BearerStrategy(
    function(token, done) {
        try {
            console.log(token);
            var decoded = jwt.verify(token, 'SecretStuffGoesHere!', { algorithm: 'http://www.w3.org/2001/04/xmldsig-more#hmac-sha256', issuer: 'localhost', audience: 'all' });
            return done(null, {name:'adsfadf'}, { scope: 'all' });
        }
        catch(error) {
            console.log(error);
            return done(error, null);
        }
    }
  ));


var app = express();
app.use(cors());
app.use(passport.initialize());

app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'EJS');
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(express.static(path.join(__dirname, 'public')));


app.use('/test', passport.authenticate('bearer', {session: false}), test);

app.use(function(req, res, next) {
  var err = new Error('Not Found');
  err.status = 404;
  next(err);
});


app.use(function(err, req, res, next) {
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};
  res.status(err.status || 500);
  res.render('error');
});



app.listen(3000, () => console.log('listening on port 3000!'))

module.exports = app;