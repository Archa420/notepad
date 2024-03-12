from flask import Flask, render_template, request, redirect, url_for
import sqlite3
import re

app = Flask(__name__)

# Function to connect to the database
def get_db_connection():
    conn = sqlite3.connect('database.db')
    conn.row_factory = sqlite3.Row
    return conn

# Function to initialize the database
def init_db():
    conn = get_db_connection()
    with app.open_resource('schema.sql', mode='r') as f:
        conn.cursor().executescript(f.read())
    conn.commit()
    conn.close()

# Initialize the database
init_db()

# Route for the homepage
@app.route('/', methods=['GET', 'POST'])
def home():
    if request.method == 'POST':
        text = request.form['text']
        word_count = len(re.findall(r'\w+', text))
        number_count = len(re.findall(r'\d+', text))
        comma_count = text.count(',')
        dot_count = text.count('.')
        
        conn = get_db_connection()
        conn.execute('INSERT INTO texts (text, word_count, number_count, comma_count, dot_count) VALUES (?, ?, ?, ?, ?)',
                     (text, word_count, number_count, comma_count, dot_count))
        conn.commit()
        conn.close()
        
        return redirect(url_for('stats'))

    return render_template('index.html')

# Route for statistics
@app.route('/stats')
def stats():
    conn = get_db_connection()
    texts = conn.execute('SELECT * FROM texts').fetchall()
    conn.close()
    return render_template('stats.html', texts=texts)

if __name__ == '__main__':
    app.run(debug=True)
