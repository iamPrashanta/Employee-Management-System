
CREATE DATABASE empmanagement;
USE empmanagement;

-- Create the 'users' table
CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment column
    role_type NVARCHAR(4) NOT NULL CHECK (role_type IN ('emp', 'admin')), -- Role type restriction
    username NVARCHAR(100) NOT NULL, -- Username column
    email NVARCHAR(150) UNIQUE NOT NULL, -- Unique email
    phone NVARCHAR(15) NOT NULL, -- Phone column
    uaddress NVARCHAR(MAX), -- Address column
    pin NVARCHAR(10), -- PIN code
    passwd NVARCHAR(255) NOT NULL, -- Password column
    parent_id INT NULL, -- Parent user ID (foreign key)
    insert_date DATETIME DEFAULT GETDATE(), -- Insert date with default value
    update_date DATETIME DEFAULT GETDATE()
);

-- Create the 'projects' table
CREATE TABLE projects (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment column
    project_name NVARCHAR(150) NOT NULL, -- Project name column
    project_details NVARCHAR(MAX), -- Project details column
    insert_date DATETIME DEFAULT GETDATE(), -- Insert date with default value
    update_date DATETIME DEFAULT GETDATE() -- Update date with default value
);

-- Create the 'assign_project' table
CREATE TABLE assign_project (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-increment column
    user_id INT NOT NULL, -- User ID (foreign key)
    project_id INT NOT NULL, -- Project ID (foreign key)
    assigned_by INT NOT NULL, -- Assigned by user ID (foreign key)
    assign_date DATETIME DEFAULT GETDATE()
);

-----------------------------

SELECT * FROM users;
SELECT * FROM projects;
SELECT * FROM assign_project;